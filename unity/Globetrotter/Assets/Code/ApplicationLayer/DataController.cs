﻿using System;
using System.Collections.Generic;
using System.Threading;

using Globetrotter.DataLayer;
using Globetrotter.DomainLayer;
using Globetrotter.PersistenceLayer;

namespace Globetrotter.ApplicationLayer
{
	public class DataController
	{
		private object m_lockObject = new object();

		public delegate void WorldBankDataFetchedEventHandler(object sender, WorldBankDataFetchedEventArgs args);
		public event WorldBankDataFetchedEventHandler WorldBankDataFetched;

		private WorldBankIndicator m_currIndicator;
		private Dictionary<string, WorldBankIndicator> m_indicators;

		public WorldBankIndicator CurrentIndicator
		{
			get
			{
				lock(m_lockObject)
				{
					return m_currIndicator;
				}
			}
		}

		public DataController()
		{
			m_indicators = new Dictionary<string, WorldBankIndicator>();
			IList<WorldBankIndicator> indicators = new IndicatorsXmlLoader().loadIndicators();

			if(indicators != null)
			{
				foreach(WorldBankIndicator indicator in indicators)
				{
					m_indicators[indicator.Code] = indicator;
				}

				if(indicators.Count > 0)
				{
					m_currIndicator = indicators[0];
				}
				else
				{
					m_currIndicator = null;
				}
			}
		}

		public WorldBankData FetchData(Country[] countries, WorldBankIndicator indicator, int yearFrom, int yearTo)
		{
			return indicator.FetchData(CountriesAsCodes(countries), yearFrom, yearTo);
		}

		public void FetchDataAsync(Country[] countries, WorldBankIndicator indicator, int yearFrom, int yearTo)
		{
			Thread thread = new Thread(delegate(){
				WorldBankData data = FetchData(countries, indicator, yearFrom, yearTo);

				OnWorldBankDataFetched(data);
			});

			thread.IsBackground = true;
			thread.Start();
		}

		public WorldBankIndicator GetIndicator(string code)
		{
			lock(m_lockObject)
			{
				return m_indicators[code];
			}
		}

		private string[] CountriesAsCodes(Country[] countries)
		{
			string[] codes = new string[countries.Length];

			for(int i = 0; i < codes.Length; i++)
			{
				codes[i] = countries[i].IsoAlphaThreeCode;
			}

			return codes;
		}

		protected void OnWorldBankDataFetched(WorldBankData data)
		{
			lock(m_lockObject)
			{
				if((WorldBankDataFetched != null) && (data != null))
				{
					WorldBankDataFetched(this, new WorldBankDataFetchedEventArgs(data));
				}
			}
		}
	}
}

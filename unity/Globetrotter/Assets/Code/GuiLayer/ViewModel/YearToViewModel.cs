﻿using System;
using System.Collections.Generic;

using Globetrotter.ApplicationLayer;
using Globetrotter.InputLayer;

namespace Globetrotter.GuiLayer.ViewModel
{
	public class YearToViewModel : ViewModelBase
	{
		private DataController m_dataController;
		
		private int m_max;

		public int Max
		{
			get
			{
				lock(m_lockObj)
				{
					return m_max;
				}
			}
		}
		
		public int YearTo
		{
			get
			{
				lock(m_lockObj)
				{
					return m_dataController.YearTo;
				}
			}
		}

		public YearToViewModel(DataController dataController, int max)
			: base()
		{
			m_dataController = dataController;

			m_max = max;
		}
		
		public void InputReceivedHandler(object sender, InputReceivedEventArgs args)
		{
			if(ReactOnInput == true)
			{
				int delta = 0;

				if(args.InputTypes.And(InputType.ScrollLeft) == InputType.ScrollLeft)
				{
					delta = -1;
				}
				
				if(args.InputTypes.And(InputType.ScrollRight) == InputType.ScrollRight)
				{
					delta = 1;
				}
				
				if(args.InputTypes.And(InputType.WipeLeft) == InputType.WipeLeft)
				{
					delta = -10;
				}
				
				if(args.InputTypes.And(InputType.WipeRight) == InputType.WipeRight)
				{
					delta = 10;
				}

				if(delta != 0)
				{
					lock(m_lockObj)
					{
						int year = m_dataController.YearTo + delta;
						
						if(year < m_dataController.YearFrom)
						{
							year = m_dataController.YearFrom;
						}
						else if(year > m_max)
						{
							year = m_max;
						}
						
						m_dataController.YearTo = year;
					}
				}
			}
		}
	}
}

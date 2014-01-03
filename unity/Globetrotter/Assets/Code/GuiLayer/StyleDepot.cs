﻿using UnityEngine;
using System.Collections;

namespace Globetrotter.GuiLayer
{
	public class StyleDepot
	{
		private static object m_staticLockObject = new object();
		private object m_lockObject = new object();

		private static StyleDepot m_instance = null;

		private GUIStyle m_focusedBoxStyle;
		private GUIStyle m_unfocusedBoxStyle;

		private GUIStyle m_selectedCountryStyle;
		private GUIStyle m_selectedCountryHoverStyle;

		public static StyleDepot Instance
		{
			get
			{
				lock(m_staticLockObject)
				{
					m_instance = new StyleDepot();
				}

				return m_instance;
			}
		}

		public GUIStyle FocusedBoxStyle
		{
			get
			{
				lock(m_lockObject)
				{
					return m_focusedBoxStyle;
				}
			}
		}
		
		public GUIStyle SelectedCountryHoverStyle
		{
			get
			{
				lock(m_lockObject)
				{
					return m_selectedCountryHoverStyle;
				}
			}
		}

		public GUIStyle SelectedCountryStyle
		{
			get
			{
				lock(m_lockObject)
				{
					return m_selectedCountryStyle;
				}
			}
		}

		public GUIStyle UnfocusedBoxStyle
		{
			get
			{
				lock(m_lockObject)
				{
					return m_unfocusedBoxStyle;
				}
			}
		}

		private StyleDepot()
		{
			m_focusedBoxStyle = new GUIStyle();
			Texture2D texture = new Texture2D(32, 32);
			/*int row = 0;
			int col =0;
			while(row < 32)
			{
				while(col < 32)
				{
					texture.
					col++;
					if(col >= 32)
					{
						col = 0;
						row++;
					}
				}
			}*/
			m_focusedBoxStyle.normal.background = texture;

			m_unfocusedBoxStyle = new GUIStyle();
			m_unfocusedBoxStyle.normal.background = texture;

			m_selectedCountryStyle = new GUIStyle();
			m_selectedCountryStyle.normal.textColor = Color.white;

			m_selectedCountryHoverStyle = new GUIStyle();
			m_selectedCountryHoverStyle.normal.textColor = Color.yellow;
		}
	}
}

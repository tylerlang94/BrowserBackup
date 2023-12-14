using Microsoft.Win32;
using System.Diagnostics;
using Serilog;


namespace ConsoleApp3
{
	enum BrowserApplication
	{
		Edge,
		InternetExplorer,
		Firefox,
		Chrome,
		Opera,
		Safari,
		Unknown
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();
			bool isOneDrive = IsOneDrive();
			string? oneDrivePath = OneDrivePath();

			if (!isOneDrive)
			{
				Console.WriteLine("Not instlaled");
			}

			Console.WriteLine(oneDrivePath);
		}

		/// <summary>
		/// Gets the default browser for the computer
		/// </summary>
		/// <returns>string browser</returns>
		public static BrowserApplication GetDefaultBrowser()
		{
			BrowserApplication browser = BrowserApplication.Unknown;

			try
			{
				using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice"))
				{
					if (userChoiceKey != null)
					{
						object progIdValue = userChoiceKey.GetValue("Progid");
						if (progIdValue != null)
						{
							string progId = progIdValue.ToString();
							switch (progId)
							{
								case "MSEdgeHTM":
									browser = BrowserApplication.Edge;
									break;
								case "IE.HTTP":
									browser = BrowserApplication.InternetExplorer;
									break;
								case "FirefoxURL":
									browser = BrowserApplication.Firefox;
									break;
								case "ChromeHTML":
									browser = BrowserApplication.Chrome;
									break;
								case "OperaStable":
									browser = BrowserApplication.Opera;
									break;
								case "SafariHTML":
									browser = BrowserApplication.Safari;
									break;
								default:
									browser = BrowserApplication.Unknown;
									break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions
				Debug.WriteLine("Error retrieving default browser: " + ex.Message);
			}

			return browser;
		}


		/// <summary>
		/// Looks to see if OneDrive is on the computer
		/// </summary>
		/// <returns>bool isInstalled</returns>
		public static bool IsOneDrive()
		{
			bool isInstalled = false;
			string oneDrivePath = "C:\\Program Files\\Microsoft OneDrive\\OneDrive.exe";
			if (File.Exists(oneDrivePath))
			{
				isInstalled = true;

			}

			return isInstalled;
		}

		/// <summary>
		/// Gets the path of OneDrive from Enviromental Variables
		/// </summary>
		/// <returns>string oneDrivePath</returns>
		public static string? OneDrivePath()
		{
			var oneDrivePath = Environment.GetEnvironmentVariable("OneDrive");

			return oneDrivePath;
		}

		/// <summary>
		/// Gets the bookmarks for the specified browser
		/// </summary>
		public void GetBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();
			switch (defaultBrowser)
			{
				case BrowserApplication.Edge:
					break;
				case BrowserApplication.InternetExplorer:
					break;
				case BrowserApplication.Firefox:
					break;
				case BrowserApplication.Chrome:
					break;
				case BrowserApplication.Opera:
					break;
				default:
					break;
			}
		}

		public void EdgeBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();

			if (defaultBrowser == BrowserApplication.Edge)
			{

			}
		}

		public void InternetExplorerBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();

			if (defaultBrowser == BrowserApplication.InternetExplorer)
			{

			}
		}

		public void FirefoxBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();

			if (defaultBrowser == BrowserApplication.Firefox)
			{

			}
		}
		public void ChromeBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();

			if (defaultBrowser == BrowserApplication.Chrome)
			{

			}
		}

		public void OperaBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();

			if (defaultBrowser == BrowserApplication.Opera)
			{

			}
		}

		public void SafariBookmarks()
		{
			BrowserApplication defaultBrowser = GetDefaultBrowser();

			if (defaultBrowser == BrowserApplication.Safari)
			{

			}
		}
	}
}

using Microsoft.Win32;
using System.Diagnostics;

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
	}
}

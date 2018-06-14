/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Demo.Demo
{
	public partial class UI_start : GComponent
	{
		public GTextField txt_title;
		public GButton btn_start;

		public const string URL = "ui://0dhcmlqibw0s13";

		public static UI_start CreateInstance()
		{
			return (UI_start)UIPackage.CreateObject("Demo","start");
		}

		public UI_start()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			txt_title = (GTextField)this.GetChild("txt_title");
			btn_start = (GButton)this.GetChild("btn_start");
		}
	}
}
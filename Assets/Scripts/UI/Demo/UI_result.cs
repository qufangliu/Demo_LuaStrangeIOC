/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Demo.Demo
{
	public partial class UI_result : GComponent
	{
		public GTextField txt_score;
		public GButton btn_home;

		public const string URL = "ui://0dhcmlqibw0s16";

		public static UI_result CreateInstance()
		{
			return (UI_result)UIPackage.CreateObject("Demo","result");
		}

		public UI_result()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			txt_score = (GTextField)this.GetChild("txt_score");
			btn_home = (GButton)this.GetChild("btn_home");
		}
	}
}
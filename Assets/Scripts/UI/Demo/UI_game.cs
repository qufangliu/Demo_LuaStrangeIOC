/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace Demo.Demo
{
	public partial class UI_game : GComponent
	{
		public GTextField txt_score;

		public const string URL = "ui://0dhcmlqibw0s15";

		public static UI_game CreateInstance()
		{
			return (UI_game)UIPackage.CreateObject("Demo","game");
		}

		public UI_game()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			txt_score = (GTextField)this.GetChild("txt_score");
		}
	}
}
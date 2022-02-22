using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

public partial class Vitals : Panel
{
	private Label Health;
	private Panel HealthBar;

    private Label Armor;
	private Panel ArmorBar;

	public Vitals()
	{
		StyleSheet.Load( "/ui/Vitals.scss" );

         // ==============[ Main Panel ]=================
		Panel main = Add.Panel( "main" );

        // ==============[ Health ]================
        Panel HealthMenu = main.Add.Panel( "HealthMenu" );
        // Icon
        Panel healthIconBack = HealthMenu.Add.Panel( "healthIconBack" );
		healthIconBack.Add.Label( "favorite", "healthIcon" );
        // Bar
		Panel healthBarBack = HealthMenu.Add.Panel( "healthBarBack" );
		HealthBar = healthBarBack.Add.Panel( "healthBar" );
        // Text
		Health = HealthMenu.Add.Label( "0", "healthText" );

        // ==============[ Armor ]================
        Panel ArmorMenu = main.Add.Panel( "ArmorMenu" );
        // Icon
        Panel armorIconBack = ArmorMenu.Add.Panel( "armorIconBack" );
		armorIconBack.Add.Label( "shield", "armorIcon" );
        // Bar
		Panel armorBarBack = ArmorMenu.Add.Panel( "armorBarBack" );
		ArmorBar = armorBarBack.Add.Panel( "armorBar" );
        // Text
		Armor = ArmorMenu.Add.Label( "0", "armorText" );
	}

	public override void Tick()
	{
		base.Tick();
		var player = Local.Pawn;
		if ( player == null ) return;

        // ==============[ Health ]================
		Health.Text = $"{player.Health.CeilToInt()}";
		HealthBar.Style.Dirty();
		HealthBar.Style.Width = Length.Percent( player.Health );

        // ==============[ Armor ]================
        Armor.Text = "0";
        ArmorBar.Style.Dirty();
		ArmorBar.Style.Width = Length.Percent( 0 ); // player.Armour
	}
}
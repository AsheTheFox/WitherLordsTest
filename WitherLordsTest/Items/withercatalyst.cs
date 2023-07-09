using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WitherLordsTest.Items
{
    public class withercatalyst : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wither Catalyst");
			Tooltip.SetDefault("The energy of a powerful, withering being.");
		}

		public override void SetDefaults()
        {
			Item.rare = 11;
			Item.value = 100000;
        }
	}
}
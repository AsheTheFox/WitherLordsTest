using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;

namespace WitherLordsTest.Enemies
{
    public class goldor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goldor");
            // Main.NPCFrameCount[NPC.type] = Main.NPCFrameCount[?]; // set to comment for now, animation later
        }

        public override void SetDefaults()
        {
            //give goldor a dark gray glow
            NPC.width = 16;
            NPC.knockBackResist = 1.0f;
            NPC.height = 32;
            NPC.damage = 9999; //instand kill contact
            NPC.defense = 80;
            NPC.lifeMax = 200000; //lol good luck ig
            NPC.value = 70000f;
            NPC.aiStyle = 3; // ai replaced later lol
            AIType = NPCID.ArmoredSkeleton; //you're a test dummy for now
            NPC.HitSound = SoundID.NPCHIT1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.boss = true;
        }

        public override void NPCLoot()
        {
            // Items.NewItem(NPCLoot.getRect(), ItemID., 1); // figure this out later
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];
            if(!player.active || player.dead)
            {
                NPC.TargetClosest(false);
                player = Main.player[NPC.target];
                if (!player.active || player.dead)
                {
                    NPC.velocity.Y -= 4;
                    if (NPC.timeLeft > 10)
                    { NPC.timeLeft = 10; }
                    return;
                }

                AITimer++;

                Vector2 fire = player.Center = NPC.Center;
                direction.Normalize();

                //Phase 1, Chase Phase
                if(AITimer <600 && AITimer%120==0 && NPC.life > NPC.lifeMax / 2)
                {
                    //greatsword attack at 0.5/s for 10 seconds, damage concept 200/300/400?
                    //chase player
                }

                else if (600 < AITimer && AITimer <= 900 && NPC.life > NPC.lifeMax / 2)
                {
                    //spawn 3 Wither Guards
                }

                //Phase 2, Zoomy Phase
                if(AITimer <600 && AITimer%60==0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //greatsword attack at 1/s for 10 seconds
                    //chase player, 50% speed increase.
                }

                else if(600 < AITimer && AITimer <= 900 && NPC.life <= NPC.lifeMax / 2)
                {
                    //spawn 6 Wither Guards
                }

                else if(600 < AITimer && AITimer <= 900 && AITimer % 12 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //fire skulls very fast whilst spawning Wither Guards
                }

                else if(AITimer > 900)
                { AITimer = 0; } //reset boi
            }
        }
    }
}
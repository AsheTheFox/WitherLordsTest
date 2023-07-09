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
    public class maxor : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Maxor");
            // Main.NPCFrameCount[NPC.type] = Main.NPCFrameCount[?]; // set to comment for now, animation later
        }

        public override void SetDefaults()
        {
            //give maxor a gray tint around the sprite
            NPC.width = 16;
            NPC.knockBackResist = 1.0f;
            NPC.height = 32;
            NPC.damage = 0;
            NPC.defense = 40;
            NPC.lifeMax = 100000; //lol good luck ig
            NPC.value = 50000f;
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
            if (!player.active || player.dead)
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
                //Phase 1
                if(AITimer <= 900 && AITimer % 45 == 0 && NPC.life > NPC.lifeMax / 2)
                {
                    //attack normally at 1.25/s for 15 seconds
                }

                else if(900 < AITimer && AITimer <= 1500 && AITimer % 12 == 0 && NPC.life > NPC.lifeMax / 2)
                {
                    //attack fast at 5/sec for 10 seconds
                }

                //Phase 2, Enraged
                else if(AITimer <=600 && AITimer % 20 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //attack normally at 3/s for 10 seconds
                }

                else if(600 < AITimer && AITimer < 900 && NPC.life <= NPC.lifeMax / 2)
                {
                    //summon 3 Wither Guards
                }
                
                else if(900 < AITimer && AITimer <= 1500 && AITimer % 6 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //attack at berzerk speeds, 10/s for 10 seconds
                }

                else if (AITimer > 1500)
                { AITimer = 0; } //reset boi
            }
        }
    }
}
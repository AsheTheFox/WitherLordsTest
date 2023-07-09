using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using WitherLordsTest.Items;

namespace WitherLordsTest.Enemies
{
    public class necron : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necron");
            // Main.NPCFrameCount[NPC.type] = Main.NPCFrameCount[?]; // set to comment for now, animation later
        }

        public override void SetDefaults()
        {
            //give necron a red glow
            NPC.width = 16;
            NPC.knockBackResist = 1.0f;
            NPC.height = 32;
            NPC.damage = 0;
            NPC.defense = 60;
            NPC.lifeMax = 250000; //lol good luck ig
            NPC.value = 75000f;
            NPC.aiStyle = 3; // ai replaced later lol
            AIType = NPCID.ArmoredSkeleton; //you're a test dummy for now
            NPC.HitSound = SoundID.NPCHIT1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Music = MusicID.Boss5; // you get music because you're last
            NPC.boss = true;
        }

        public override void NPCLoot()
        {
            NPCLoot.Add(ItemDropRule.Common(ModContent.ItemType<withercatalyst>(), 10, 1, 1));
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

                //Phase 1, necron, but maxor. give him a light gray tint in Maxor phase.
                if(AITimer <=900 && AITimer % 45==0 && NPC.life > NPC.lifeMax / 4)
                {
                    //attack normally at 0.75/s for 15 seconds
                }
                else if (900 <= AITimer && AITimer < 1500 && AITimer % 12 == 0 && NPC.life > NPC.lifeMax * 0.75)
                {
                    //attack fast at 5/sec for 10 seconds
                }
                else if(1500 <= AITimer && AITimer < 2400 && AITimer % 45 == 0 && NPC.life > NPC.lifeMax * 0.75)
                {
                    //redo attack 1
                }
                else if(2400 <= AITimer && AITimer < 3000 && AITimer % 12 == 0 && NPC.life > NPC.lifeMax * 0.75)
                {
                    //redo attack 2
                }
                //Phase 2, necron, but storm. give him a blue tint in Storm phase.
                else if(AITimer < 600 && AITimer % 60 == 0 && NPC.life > NPC.lifeMax / 2 && NPC.life <= NPC.lifeMax * 0.75)
                {
                    //attack normally at 1/s for 10 seconds
                }
                
                else if(600 <= AITimer && AITimer < 900 && NPC.life > NPC.lifeMax / 2 && NPC.life <= NPC.lifeMax * 0.75)
                {
                    //summon 5 Wither Guards. It's Necron, he don't play.
                }

                else if(900 <= AITimer && AITimer < 1500 && NPC.life > NPC.lifeMax / 2 && NPC.life <= NPC.lifeMax * 0.75)
                {
                    //wither beam attack
                }
                else if(1500 <= AITimer && AITimer < 2400 && AITimer % 60 == 0 && NPC.life > NPC.lifeMax / 2 && NPC.life <= NPC.lifeMax * 0.75)
                {
                    //repeat attack 1
                    //attack normally at 1/s for 15 seconds
                }
                else if(2400 <= AITimer && AITimer < 3000 && AITimer % 9 == 0 && NPC.life > NPC.lifeMax / 2 && NPC.life <= NPC.lifeMax * 0.75)
                {
                    //frenzy attack for 10 seconds, slightly faster than Storm's.
                }
                //Phase 3, necron, but goldor. give him a dark gray tint and red eyes in Goldor Phase.
                else if(AITimer <1200 && AITimer%60==0 && NPC.life < NPC.lifeMax / 4 && NPC.life <= NPC.lifeMax / 2)
                {
                    //phase 2 goldor attack speed and movement speed. give him 9999 contact damage like Goldor.
                }

                else if(1200 < AITimer && AITimer <= 1500 && NPC.life < NPC.lifeMax / 4 && NPC.life <= NPC.lifeMax / 2)
                {
                    //spawn 8 Wither Guards. you're getting screwed now boi.
                }

                else if(1200 < AITimer && AITimer <= 1500 && AITimer % 12 == 0 && NPC.life < NPC.lifeMax / 4 && NPC.life <= NPC.lifeMax / 2)
                {
                    //fire skulls very fast whilst spawning Wither Guards
                }
                else if(1500 < AITimer && AITImer <= 2700 && AITimer%60==0 && NPC.life < NPC.lifeMax / 4 && NPC.life <= NPC.lifeMax / 2)
                {
                    //repeat attack 1.
                }
                else if(2700 < AITimer && AITimer <= 3000 && NPC.life < NPC.lifeMax / 4 && NPC.life <= NPC.lifeMax / 2)
                {
                    //spawn 8 Wither Guards.
                }

                else if(2700 < AITimer && AITimer <= 3000 && AITimer % 12 == 0 && NPC.life < NPC.lifeMax / 4 && NPC.life <= NPC.lifeMax / 2)
                {
                    //owey skull go shooty shooty and i get hurty hurty
                }
                //Phase 4, necron, but... oh sh*t it's actually necron.
                else if(AITimer < 1200 && AITimer % 12 == 0 && NPC.life <= NPC.lifeMax / 4)
                {
                    //shooty shooty skull very fast.
                }
                else if(1200 < AITimer && AITimer <= 1800 && NPC.life <= NPC.lifeMax / 4)
                {
                    //maxor lazer but 4 of them. cross shape go pew pew pew zap zap die
                }
                else if(1800 < AITimer && AITimer <= 3000 && NPC.life <= NPC.lifeMax / 4)
                {
                    //continue to do the shooty skull attack
                }
                else if(2700 <AITimer && AITimer <= 3000 && NPC.life <= NPC.lifeMax / 4)
                {
                    // summon 8 Wither Guards while shooting skulls. continue shooting skulls.
                }

                else if(AITimer > 3000)
                { AITimer = 0; } //reset boi
            }
        }
    }
}
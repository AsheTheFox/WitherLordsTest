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
    public class storm : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm");
            // Main.NPCFrameCount[NPC.type] = Main.NPCFrameCount[?]; // set to comment for now, animation later
        }

        public override void SetDefaults()
        {
            //give storm a blue tint around the sprite
            NPC.width = 16;
            NPC.knockBackResist = 1.0f;
            NPC.height = 32;
            NPC.damage = 0;
            NPC.defense = 30;
            NPC.lifeMax = 150000; //lol good luck ig
            NPC.value = 60000f;
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
                if(AITimer < 600 && AITimer % 60 == 0 && NPC.life > NPC.lifeMax / 2)
                {
                    //attack normally at 1/s for 10 seconds
                }
                
                else if(600 <= AITimer && AITimer < 900 && NPC.life > NPC.lifeMax / 2)
                {
                    //summon 3 Wither Guards
                }

                else if(900 <= AITimer && AITimer < 1500 && NPC.life > NPC.lifeMax / 2)
                {
                    //fire a beam that does lots of damage based on difficulty (yes i plan expert and master mode variants)
                    //conceptualization? Stargazer beam that does 300/450/600 damage. should be devastating.
                    // 10 second phase
                }
                else if(1500 <= AITimer && AITimer < 2100 && AITimer % 60 == 0 && NPC.life > NPC.lifeMax / 2)
                {
                    //repeat attack 1
                    //attack normally at 1/s for 10 seconds
                }
                else if(2100 <= AITimer && AITimer < 2700 && AITimer % 12 == 0 && NPC.life > NPC.lifeMax / 2)
                {
                    //frenzy attack for 10 seconds.
                }

                //Phase 2, Enraged Speeds and increased Wither Blast Damage.
                if(AITimer < 600 && AITimer % 30 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //attack normally at 2/s for 10 seconds
                }
                
                else if(600 <= AITimer && AITimer < 900 && NPC.life <= NPC.lifeMax / 2)
                {
                    //summon 5 Wither Guards
                }

                else if(900 <= AITimer && AITimer < 1500 && NPC.life <= NPC.lifeMax / 2)
                {
                    //the beam attack again
                    //damage increased from 300/450/600 to 400/575/750. Good luck in master mode, loser.
                }
                else if(1500 <= AITimer && AITimer < 2100 && AITimer % 30 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //repeat attack 1
                    //attack normally at 2/s for 10 seconds
                }
                else if(2100 <= AITimer && AITimer < 2700 && AITimer % 6 == 0 && NPC.life <= NPC.lifeMax / 2)
                {
                    //frenzy attack for 10 seconds, fast as f*ck boi
                }
                
                else if (AITimer >= 2700)
                { AITimer = 0; } //reset boi
            }
        }
    }
}
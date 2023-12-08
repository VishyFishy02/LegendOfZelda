
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;

namespace LegendofZelda.SpriteFactories
{
    public class SoundFactory : ISpriteFactory
    {
        private static SoundFactory instance = new SoundFactory();
        SoundEffect enemy_hit;
        SoundEffect link_attack;
        SoundEffect item_drop;
        SoundEffect item_pickup;
        SoundEffect link_damage;
        SoundEffect throw_projectile;
        SoundEffect link_death;
        SoundEffect winning;

        public static SoundFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private SoundFactory()
        {
        }


        public void loadContent(ContentManager content)
        {
            enemy_hit = content.Load<SoundEffect>("enemy_hit");
            link_attack = content.Load<SoundEffect>("hee_hee");
            item_drop = content.Load<SoundEffect>("item_drop");
            item_pickup = content.Load<SoundEffect>("item_pickup");
            link_damage = content.Load<SoundEffect>("link_damage");
            throw_projectile = content.Load<SoundEffect>("throw_projectile");
            link_death = content.Load<SoundEffect>("link_death");
            winning = content.Load<SoundEffect>("winning_sound");
        }


        public SoundEffect CreateSoundEffect(string name)
        {
            switch (name)
            {
                case "EnemyHit":

                    return enemy_hit;

                case "LinkAttack":

                    return link_attack;

                case "ItemDrop":

                    return item_drop;

                case "ItemPickup":

                    return item_pickup;

                case "LinkDamage":

                    return link_damage;

                case "ThrowProjectile":

                    return throw_projectile;

                case "LinkDeath":

                    return link_death;

                case "Winning":

                    return winning;

                default:

                    return null;
            }

        }

    }
}
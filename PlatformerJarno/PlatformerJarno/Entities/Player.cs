﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PlatformerJarno.Animations;
using PlatformerJarno.Controller;


namespace PlatformerJarno.Entities
{

    class Player : Entity
    {
        // Properties
        private InputHandler _input;
        private Animation _currentAnimation;
        private Animation _idleAnimation;
        private Animation _walkAnimation;
        private Animation _jumpAnimation;

        // Constructor
        public Player(ContentManager content, string path, Vector2 startPosition, ICollection<Entity> entities, float scale = 1 ,int health = 5) : base(content, path, startPosition, entities, scale, health)
        {
            _input = new InputHandler(this);
            CreateAnimations(20, 20);
        }

        // Methods
        public override void Update(GameTime gameTime)
        {
            _input.HandleInput();
            _currentAnimation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.ViewRectangle = _currentAnimation.CurrentFrame.SourceRectangle;
            if (facing == Facing.Right) sprite.Draw(spriteBatch, position: Position);
            if (facing == Facing.Left) sprite.Draw(spriteBatch, true, Position);
        }
        
        public void Idle()
        {

        }

        public override void WalkLeft()
        {
            facing = Facing.Left;
        }

        public override void WalkRight()
        {
            facing = Facing.Right;
        }

        public void Jump()
        {

        }

        public void Attack()
        {

        }

        private void CreateAnimations(int width, int height)
        {
            #region Idle

            int y = 2;

            _idleAnimation = new Animation(8);
            for (int i = 0; i < 5; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _idleAnimation.AddFrame(r);
            }

            #endregion

            #region Jump

            y = 25;
            int j = 0;
            _jumpAnimation = new Animation(7);
            for (int i = 0; i < 4; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _jumpAnimation.AddFrame(r);
                j = i;
            }

            y -= 2;
            ++j;
            int k = 0;
            for (int i = j; i < j + 3; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _jumpAnimation.AddFrame(r);
                k = 0;
            }

            for (int i = k; i < k + 2; i++)
            {
                y += 1;
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _jumpAnimation.AddFrame(r);
            }
            #endregion

            #region Walk
            
            y = 47;

            _walkAnimation = new Animation(15);
            for (int i = 0; i < 10; i++)
            {
                Rectangle r = new Rectangle((5 + (i * (width + 6))), y, width, height);
                _walkAnimation.AddFrame(r);
            }
            #endregion

            sprite.ViewRectangle = new Rectangle(0, 0, width, height);
            _currentAnimation = _idleAnimation;
        }
    }
}

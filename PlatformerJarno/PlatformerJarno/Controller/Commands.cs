﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerJarno.Entities;

namespace PlatformerJarno.Controller
{
    // Class to execute the actions he receives trough parameter
    // Command pattern
    class Commands: ICommand
    {
        public void Excecute(Player player, InputHandler.ControlAction action)
        {
            switch (action)
            {
                case InputHandler.ControlAction.Left:
                    player.WalkLeft();
                    break;
                case InputHandler.ControlAction.Right:
                    player.WalkRight();
                    break;
                case InputHandler.ControlAction.Jump:
                    player.Jump();
                    break;
                case InputHandler.ControlAction.Attack:
                    player.Attack();
                    break;
                default:
                    player.Idle();
                    break;
            }
        }
    }
}

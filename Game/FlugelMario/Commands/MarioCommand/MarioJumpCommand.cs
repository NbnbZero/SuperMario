﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
namespace SuperMario.Commands.ControllerCommand
{
    class MarioJumpCommand : ICommand
    {
        private IMario mario;

        public MarioJumpCommand(IMario Mario)
        {
            mario = Mario;
        }

        public void Execute()
        {

            mario.State.JumpOrStand();
            
        }
    }
}

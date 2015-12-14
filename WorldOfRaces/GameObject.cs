﻿using System;
using RPG_Ned.Engine;
using RPG_Ned.Exceptions;

namespace RPG_Ned
{
    public abstract class GameObject
    {
        private Position position;
        private char objectSymbol;

        protected GameObject(Position position, char objectSymbol)
        {
            this.Position = position;
            this.ObjectSymbol = objectSymbol;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                // Added upper-bound check
                if (value.X < 0
                    || value.Y < 0
                    || value.X >= GameEngine.MapWidth
                    || value.Y >= GameEngine.MapHeight)
                {
                    throw new ObjectOutsideOfMapException("Specified coordinates are outside map.");
                }

                this.position = value;
            }
        }

        public char ObjectSymbol
        {
            get
            {
                return this.objectSymbol;
            }

            set
            {
                if (!char.IsUpper(value))
                {
                    throw new ArgumentOutOfRangeException(
                        "objectSymbol",
                        "Object symbol must be an upper-case letter.");
                }

                this.objectSymbol = value;
            }
        } 
    }
}
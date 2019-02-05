using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectGates.Model.Resources;
using SFML.Graphics;

namespace ProjectGates.Model.Entities.Passive
{

    class Title : PassiveEntity, ITransparent
    {
        private Text Text { get; set; }

        public PGPercent Transparency
        {
            get
            {
                return (PGPercent)((PGFloat)Text.Color.A / 255);
            }
            set
            {
                var old = Text.Color;
                var newColor = new Color(old.R, old.G, old.B, (byte)((float)value * 255));
                Text.Color = newColor;
            }
        }

        public Title(string text)
        {
            Text = new Text(text, ResourceFonts.GetGlobalResource(ResourceFonts.Key.Main))
            {
                CharacterSize = (uint)(0.03f * (float)Engine.MainWindow.Size.Y),
                Color = Color.White,           
            };
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectGates.Model.Resources;
using SFML.Graphics;

namespace ProjectGates.Model.Entities.Passive
{

    class Title : PassiveEntity
    {
        private Text Text { get; set; }

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

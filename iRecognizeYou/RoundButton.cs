using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace iRecognizeYou
{
	class RoundButton :EllipticalButton.EllipticalButton
	{
		protected override void OnMouseHover( EventArgs e )
		{
			base.BackColor = Color.Orange;
			base.OnMouseHover(e);
			
		}
		protected override void OnMouseLeave( EventArgs e )
		{
			base.BackColor = Color.WhiteSmoke;
			base.OnMouseLeave(e);
		}
	
	}
}

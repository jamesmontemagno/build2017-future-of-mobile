using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace MasterDetailDemo
{
    public class CrazyCircleView : UIView
    {
        CGPoint location = new CGPoint(100, 200);
        CGSize size = new CGSize(75, 75);
        UIColor background = UIColor.Purple;
        public CrazyCircleView()
        {
            BackgroundColor = background;
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            //Grab touches and update location

            var touch = touches.ToArray<UITouch>()[0];
            location = touch.LocationInView(this);
           
            //TODO: set background color
            SetNeedsDisplay();
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            //TODO: set diferent background color
            SetNeedsDisplay();
        }


        public override void Draw(CGRect rect)
        {
            var c = UIGraphics.GetCurrentContext();
            background.SetColor();
            c.FillRect(rect);
            UIColor.White.SetFill();
            c.FillEllipseInRect(new CGRect(location, size));
        }

    }
}

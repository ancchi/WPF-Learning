using System;
using System.Windows;
using System.Windows.Controls;

namespace MyDiagonalPanel.Panels {
    class MyDiagonalPanel : Panel {

        // Messen der Größe eines XAML-Elements
        protected override Size MeasureOverride(Size availableSize) {

            // Mindestgröße des DiagonalPanels
            Size desiredSize = new Size(0, 0);

            // benötigte Größe für das Panel anhand der Größe der Kindelemente ermitteln
            // die Größe der Kindelemente wird in XAML definiert
            foreach (UIElement uiElement in this.InternalChildren) {

                uiElement.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));

                desiredSize.Height += uiElement.DesiredSize.Height;
                desiredSize.Width += uiElement.DesiredSize.Width;
            }
            return desiredSize;
        }

        // Anordnen der XAML-Elemente anhand ihrer Größe
        protected override Size ArrangeOverride(Size finalSize) {

            Point childPos = new Point(0, 0);

            foreach (UIElement uiElement in this.InternalChildren) {
                // childPos kommt von struct Point und enthält die Punkte oben links (X, Y) vom Rechteck
                // DesiredSize enthält Width und Height eines Elementes in XAML
                uiElement.Arrange(new Rect(childPos, uiElement.DesiredSize));

                childPos.X += uiElement.DesiredSize.Width;
                childPos.Y += uiElement.DesiredSize.Height;

            }
            return finalSize;
        }
    }
}

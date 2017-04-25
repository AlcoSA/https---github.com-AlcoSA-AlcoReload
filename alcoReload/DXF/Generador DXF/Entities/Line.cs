﻿#region DXF.Generador_DXF, Copyright(C) 2015 Daniel Carvajal, Licensed under LGPL.
// 
//                         DXF.Generador_DXF library
//  Copyright (C) 2009-2015 Daniel Carvajal (haplokuon@gmail.com)
//  
//  This library is free software; you can redistribute it and/or
//  modify it under the terms of the GNU Lesser General Public
//  License as published by the Free Software Foundation; either
//  version 2.1 of the License, or (at your option) any later version.
//  
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//  FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//  COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//  IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//  CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using DXF.Generador_DXF.Tables;
using System.Drawing;

namespace DXF.Generador_DXF.Entities
{
    /// <summary>
    /// Represents a line <see cref="EntityObject">entity</see>.
    /// </summary>
    public class Line :
        EntityObject
    {
        #region private fields

        private Vector3 start;
        private Vector3 end;
        private double thickness;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Line</c> class.
        /// </summary>
        public Line()
            : this(Vector3.Zero, Vector3.Zero)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>Line</c> class.
        /// </summary>
        /// <param name="startPoint">Line <see cref="Vector2">start point.</see></param>
        /// <param name="endPoint">Line <see cref="Vector2">end point.</see></param>
        public Line(Vector2 startPoint, Vector2 endPoint)
            : this(new Vector3(startPoint.X, startPoint.Y, 0.0), new Vector3(endPoint.X, endPoint.Y, 0.0))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>Line</c> class.
        /// </summary>
        /// <param name="startPoint">Line start <see cref="Vector3">point.</see></param>
        /// <param name="endPoint">Line end <see cref="Vector3">point.</see></param>
        public Line(Vector3 startPoint, Vector3 endPoint) 
            : base(EntityType.Line, DxfObjectCode.Line)
        {
            this.start = startPoint;
            this.end = endPoint;
            this.thickness = 0.0;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the line <see cref="Vector3">start point</see>.
        /// </summary>
        public Vector3 StartPoint
        {
            get { return this.start; }
            set { this.start = value; }
        }

        /// <summary>
        /// Gets or sets the line <see cref="Vector3">end point</see>.
        /// </summary>
        public Vector3 EndPoint
        {
            get { return this.end; }
            set { this.end = value; }
        }

        /// <summary>
        /// Gets the direction of the line.
        /// </summary>
        public Vector3 Direction
        {
            get { return this.end - this.start; }
        }
        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        public double Thickness
        {
            get { return this.thickness ; }
            set { this.thickness = value; }
        }

        #endregion

        #region overrides

        /// <summary>
        /// Creates a new Line that is a copy of the current instance.
        /// </summary>
        /// <returns>A new Line that is a copy of this instance.</returns>
        public override object Clone()
        {
            Line entity = new Line
            {
                //EntityObject properties
                Layer = (Layer)this.layer.Clone(),
                LineType = (LineType)this.lineType.Clone(),
                Color = (AciColor)this.color.Clone(),
                Lineweight = (Lineweight)this.lineweight.Clone(),
                Transparency = (Transparency)this.transparency.Clone(),
                LineTypeScale = this.lineTypeScale,
                Normal = this.normal,
                //Line properties
                StartPoint = this.start,
                EndPoint = this.end,
                Thickness = this.thickness,
            };

            foreach (XData data in this.XData.Values)
                entity.XData.Add((XData)data.Clone());

            return entity;

        }

        public override void Draw(Graphics g, float factorzoom, float[] factor_traslacion)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            #region Lápiz
            Pen p = new Pen(this.Color.ToColor(), lineweight.Value);
            if (this.LineType.Name == LineType.Dashed.Name)
            {
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            else if (this.LineType.Name == LineType.DashDot.Name)
            { p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; }
            else if (this.LineType.Name == LineType.Dot.Name)
            { p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; }
            else
            { p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; }
            #endregion
            g.DrawLine(p, (float)(start.X * factorzoom)+factor_traslacion[0],
                (float)(start.Y * factorzoom)+factor_traslacion[1],
                (float)(end.X * factorzoom)+factor_traslacion[0],
                (float)(end.Y * factorzoom)+factor_traslacion[1]);
        }

        #endregion

    }
}
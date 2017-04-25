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

using System;
using System.Collections.Generic;
using System.Drawing;
using DXF.Generador_DXF.Objects;
using DXF.Generador_DXF.Tables;

namespace DXF.Generador_DXF.Entities
{
    /// <summary>
    /// Represents a multiline <see cref="EntityObject">entity</see>.
    /// </summary>
    public class MLine:
        EntityObject
    {
        #region delegates and events

        public delegate void MLineStyleChangeEventHandler(MLine sender, TableObjectChangeEventArgs<MLineStyle> e);
        public event MLineStyleChangeEventHandler MLineStyleChange;
        protected virtual MLineStyle OnMLineStyleChangeEvent(MLineStyle oldMLineStyle, MLineStyle newMLineStyle)
        {
            MLineStyleChangeEventHandler ae = this.MLineStyleChange;
            if (ae != null)
            {
                TableObjectChangeEventArgs<MLineStyle> eventArgs = new TableObjectChangeEventArgs<MLineStyle>(oldMLineStyle, newMLineStyle);
                ae(this, eventArgs);
                return eventArgs.NewValue;
            }
            return newMLineStyle;
        }

        #endregion

        #region private fields

        private double scale;
        private MLineStyle style;
        private MLineJustification justification;
        private double elevation;
        private MLineFlags flags;
        private List<MLineVertex> vertexes;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>MLine</c> class.
        /// </summary>
        public MLine()
            : this(new List<Vector2>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>MLine</c> class.
        /// </summary>
        /// <param name="vertexes">Multiline <see cref="Vector2">vertex</see> location list in object coordinates.</param>
        /// <param name="isClosed">Sets if the multiline is closed</param>
        public MLine(ICollection<Vector2> vertexes, bool isClosed = false)
            : this(vertexes, MLineStyle.Default, 1.0, isClosed)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>MLine</c> class.
        /// </summary>
        /// <param name="vertexes">Multiline <see cref="Vector2">vertex</see> location list in object coordinates.</param>
        /// <param name="scale">Multiline scale.</param>
        /// <param name="isClosed">Sets if the multiline is closed</param>
        public MLine(ICollection<Vector2> vertexes, double scale, bool isClosed = false)
            : this(vertexes, MLineStyle.Default, scale, isClosed)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>MLine</c> class.
        /// </summary>
        /// <param name="vertexes">MLine <see cref="Vector2">vertex</see> location list in object coordinates.</param>
        /// <param name="style">MLine <see cref="MLineStyle">style.</see></param>
        /// <param name="scale">MLine scale.</param>
        /// <param name="isClosed">Sets if the multiline is closed</param>
        public MLine(ICollection<Vector2> vertexes, MLineStyle style, double scale, bool isClosed = false)
            : base(EntityType.MLine, DxfObjectCode.MLine)
        {
            this.scale = scale;
            if (style == null)
                throw new ArgumentNullException("style", "The MLine style cannot be null.");
            if (isClosed)
                this.flags = MLineFlags.Has | MLineFlags.Closed;
            else
                this.flags = MLineFlags.Has;

            this.style = style;
            this.justification = MLineJustification.Zero;
            this.elevation = 0.0;
            if (vertexes == null)
                throw new ArgumentNullException("vertexes");
            this.SetVertexes(vertexes);
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets the multiline <see cref="MLineVertex">segments</see> list.
        /// </summary>
        public List<MLineVertex> Vertexes
        {
            get { return this.vertexes; }
        }

        /// <summary>
        /// Gets or sets the multiline elevation.
        /// </summary>
        public double Elevation
        {
            get { return this.elevation; }
            set { this.elevation = value; }
        }

        /// <summary>
        /// Gets or sets the multiline scale.
        /// </summary>
        /// <remarks>AutoCad accepts negative scales, but it is not recommended. </remarks>
        public double Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }

        /// <summary>
        /// Gets or sets if the multiline is closed.
        /// </summary>
        public bool IsClosed
        {
            get { return (this.flags & MLineFlags.Closed) == MLineFlags.Closed; }
            set
            {
                if (value)
                    this.flags |= MLineFlags.Closed;
                else
                    this.flags &= ~MLineFlags.Closed;
            }
        }

        /// <summary>
        /// Gets or sets the suppression of start caps.
        /// </summary>
        public bool NoStartCaps
        {
            get { return (this.flags & MLineFlags.NoStartCaps) == MLineFlags.NoStartCaps; }
            set
            {
                if (value)
                    this.flags |= MLineFlags.NoStartCaps;
                else
                    this.flags &= ~MLineFlags.NoStartCaps;
            }
        }

        /// <summary>
        /// Gets or sets the suppression of end caps.
        /// </summary>
        public bool NoEndCaps
        {
            get { return (this.flags & MLineFlags.NoEndCaps) == MLineFlags.NoEndCaps; }
            set
            {
                if (value)
                    this.flags |= MLineFlags.NoEndCaps;
                else
                    this.flags &= ~MLineFlags.NoEndCaps;
            }
        }

        /// <summary>
        /// Gets or sets the multiline justification.
        /// </summary>
        public MLineJustification Justification
        {
            get { return this.justification; }
            set { this.justification = value; }
        }

        /// <summary>
        /// Gets or set the multiline style.
        /// </summary>
        public MLineStyle Style
        {
            get { return this.style; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", "The MLine style cannot be null.");
                this.style = this.OnMLineStyleChangeEvent(this.style, value);
            }
        }

        #endregion

        #region internal properties

        /// <summary>
        /// MLine flags.
        /// </summary>
        internal MLineFlags Flags
        {
            get { return this.flags; }
            set { this.flags = value; }
        }

        #endregion

        #region public methods
        
        /// <summary>
        /// Calculates the internal information of the multiline vertexes.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function will be called when the entity is created or when setting its vertexes;
        /// but, afterwards, this function will need to be called manually if any modifications are done to the multiline.
        /// </para>
        /// <para>
        /// If the vertex distance list needs to be edited to represent trimmed multilines this function needs to be called prior any modification.
        /// It will calculate the minimum information needed to build a correct multiline.
        /// </para>
        /// </remarks>
        public void CalculateVertexesInfo()
        {
            if (this.vertexes.Count == 0)
                return;

            double reference = 0.0;
            switch (this.justification)
            {
                case MLineJustification.Top:
                    reference = this.style.Elements[this.style.Elements.Count - 1].Offset;
                    break;
                case MLineJustification.Zero:
                    reference = 0.0;
                    break;
                case MLineJustification.Bottom:
                    reference = this.style.Elements[0].Offset;
                    break;
            }

            Vector2 prevDir;
            if (Equals(this.vertexes[0].Location, this.vertexes[this.vertexes.Count - 1].Location))
                prevDir = Vector2.UnitY;
            else
            {
                prevDir = this.vertexes[0].Location - this.vertexes[this.vertexes.Count - 1].Location;
                prevDir.Normalize();
            }

            for (int i = 0; i < this.vertexes.Count; i++)
            {
                Vector2 position = this.vertexes[i].Location;
                Vector2 mitter;
                Vector2 dir;
                if (i == 0)
                {
                    if (Equals(this.vertexes[i + 1].Location, position))
                        dir = Vector2.UnitY;
                    else
                    {
                        dir = this.vertexes[i + 1].Location - position;
                        dir.Normalize();
                    }
                    if (this.IsClosed)
                    {
                        mitter = prevDir - dir;
                        mitter.Normalize();
                    }
                    else
                        mitter = MathHelper.Transform(dir, this.style.StartAngle * MathHelper.DegToRad, MathHelper.CoordinateSystem.Object, MathHelper.CoordinateSystem.World);

                }
                else if (i + 1 == this.vertexes.Count)
                {
                    if (this.IsClosed)
                    {
                        if (Equals(this.vertexes[0].Location, position))
                            dir = Vector2.UnitY;
                        else
                        {
                            dir = this.vertexes[0].Location - position;
                            dir.Normalize();
                        }
                        mitter = prevDir - dir;
                        mitter.Normalize();
                    }
                    else
                    {
                        dir = prevDir;
                        mitter = MathHelper.Transform(dir, this.style.EndAngle * MathHelper.DegToRad, MathHelper.CoordinateSystem.Object, MathHelper.CoordinateSystem.World);
                    }

                }
                else
                {
                    if (Equals(this.vertexes[i + 1].Location, position))
                        dir = Vector2.UnitY;
                    else
                    {
                        dir = this.vertexes[i + 1].Location - position;
                        dir.Normalize();
                    }

                    mitter = prevDir - dir;
                    mitter.Normalize();
                }
                prevDir = dir;

                List<double>[] distances = new List<double>[this.style.Elements.Count];
                double angleMitter = Vector2.Angle(mitter);
                double angleDir = Vector2.Angle(dir);
                double cos = Math.Cos(angleMitter + (MathHelper.HalfPI - angleDir));
                for (int j = 0; j < this.style.Elements.Count; j++)
                {
                    double distance = (this.style.Elements[j].Offset + reference) / cos;
                    distances[j] = new List<double>
                                               {
                                                   distance*this.scale,
                                                   0.0
                                               };
                }

                this.vertexes[i] = new MLineVertex(position, dir, mitter, distances);
            }
        }

        /// <summary>
        /// Sets the positions of the multiline vertexes. 
        /// </summary>
        /// <param name="points">A list of <see cref="Vector3">points</see> that make up the multiline vertex list.</param>
        public void SetVertexes(ICollection<Vector2> points)
        {
            this.vertexes = new List<MLineVertex>(points.Count);
            foreach (Vector2 point in points)
            {
                this.vertexes.Add(new MLineVertex(point, Vector2.Zero, Vector2.Zero, null));
            }
            this.CalculateVertexesInfo();
        }
        
        #endregion

        #region overrides

        /// <summary>
        /// Creates a new MLine that is a copy of the current instance.
        /// </summary>
        /// <returns>A new MLine that is a copy of this instance.</returns>
        public override object Clone()
        {        
            MLine entity = new MLine
            {
                //EntityObject properties
                Layer = (Layer)this.layer.Clone(),
                LineType = (LineType)this.lineType.Clone(),
                Color = (AciColor)this.color.Clone(),
                Lineweight = (Lineweight)this.lineweight.Clone(),
                Transparency = (Transparency)this.transparency.Clone(),
                LineTypeScale = this.lineTypeScale,
                Normal = this.normal,
                //MLine properties
                Elevation = this.elevation,
                Scale = this.scale,
                Justification = this.justification,
                Style = this.style,
                Flags = this.Flags
            };

            foreach (MLineVertex vertex in this.vertexes)
                entity.vertexes.Add((MLineVertex)vertex.Clone());

            foreach (XData data in this.XData.Values)
                entity.XData.Add((XData)data.Clone());

            return entity;

        }

        public override void Draw(Graphics g, float factorzoom, float[] factor_traslacion)
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        }   

    #endregion
}
}

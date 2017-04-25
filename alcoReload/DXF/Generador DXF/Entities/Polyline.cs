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
using DXF.Generador_DXF.Tables;

namespace DXF.Generador_DXF.Entities
{
    /// <summary>
    /// Represents a generic polyline <see cref="EntityObject">entity</see>.
    /// </summary>
    public class Polyline :
        EntityObject
    {
        #region private fields

        private readonly EndSequence endSequence;
        private List<PolylineVertex> vertexes;
        private PolylineTypeFlags flags;
        private readonly PolylineSmoothType smoothType;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <c>Polyline3d</c> class.
        /// </summary>
        /// <param name="vertexes">3d polyline <see cref="PolylineVertex">vertex</see> list.</param>
        /// <param name="isClosed">Sets if the polyline is closed.</param>
        public Polyline(List<PolylineVertex> vertexes, bool isClosed = false) 
            : base (EntityType.Polyline, DxfObjectCode.Polyline)
        {
            if (vertexes == null)
                throw new ArgumentNullException("vertexes");
            this.vertexes = vertexes;
            this.flags = isClosed ? PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM | PolylineTypeFlags.Polyline3D : PolylineTypeFlags.Polyline3D;
            this.smoothType = PolylineSmoothType.NoSmooth;
            this.endSequence = new EndSequence();
        }

        /// <summary>
        /// Initializes a new instance of the <c>Polyline3d</c> class.
        /// </summary>
        public Polyline()
            : this(new List<PolylineVertex>())
        {
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets the polyline <see cref="PolylineVertex">vertex</see> list.
        /// </summary>
        public List<PolylineVertex> Vertexes
        {
            get { return this.vertexes; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                this.vertexes = value;
            }
        }

        /// <summary>
        /// Gets or sets if the polyline is closed.
        /// </summary>
        public bool IsClosed
        {
            get { return (this.flags & PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM) == PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM; }
            set
            {
                if (value)
                    this.flags |= PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM;
                else
                    this.flags &= ~PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM;
            }
        }

        /// <summary>
        /// Enable or disable if the line type pattern is generated continuously around the vertexes of the polyline.
        /// </summary>
        public bool LineTypeGeneration
        {
            get { return (this.flags & PolylineTypeFlags.ContinuousLineTypePattern) == PolylineTypeFlags.ContinuousLineTypePattern; }
            set
            {
                if (value)
                    this.flags |= PolylineTypeFlags.ContinuousLineTypePattern;
                else
                    this.flags &= ~PolylineTypeFlags.ContinuousLineTypePattern;
            }
        }

        /// <summary>
        /// Gets the curve smooth type.
        /// </summary>
        public PolylineSmoothType SmoothType
        {
            get { return this.smoothType; }
        }

        #endregion

        #region internal properties

        /// <summary>
        /// Gets the polyline type.
        /// </summary>
        internal PolylineTypeFlags Flags
        {
            get { return this.flags; }
            set { this.flags = value; }
        }

        /// <summary>
        /// Gets the end vertex sequence.
        /// </summary>
        internal EndSequence EndSequence
        {
            get { return this.endSequence; }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Decompose the actual polyline in a list of <see cref="Line">lines</see>.
        /// </summary>
        /// <returns>A list of <see cref="Line">lines</see> that made up the polyline.</returns>
        public List<EntityObject> Explode()
        {
            List<EntityObject> entities = new List<EntityObject>();
            int index = 0;
            foreach (PolylineVertex vertex in this.Vertexes)
            {
                Vector3 start;
                Vector3 end;

                if (index == this.Vertexes.Count - 1)
                {
                    if (!this.IsClosed) break;
                    start = vertex.Location;
                    end = this.vertexes[0].Location;
                }
                else
                {
                    start = vertex.Location;
                    end = this.vertexes[index + 1].Location;
                }

                entities.Add(new Line
                {
                    Layer = (Layer)this.layer.Clone(),
                    LineType = (LineType)this.lineType.Clone(),
                    Color = (AciColor)this.color.Clone(),
                    Lineweight = (Lineweight)this.lineweight.Clone(),
                    Transparency = (Transparency)this.transparency.Clone(),
                    LineTypeScale = this.lineTypeScale,
                    Normal = this.normal,
                    StartPoint = start,
                    EndPoint = end,
                });

                index++;
            }

            return entities;
        }

        #endregion

        #region overrides

        /// <summary>
        /// Assigns a handle to the object based in a integer counter.
        /// </summary>
        /// <param name="entityNumber">Number to assign.</param>
        /// <returns>Next available entity number.</returns>
        /// <remarks>
        /// Some objects might consume more than one, is, for example, the case of polylines that will assign
        /// automatically a handle to its vertexes. The entity number will be converted to an hexadecimal number.
        /// </remarks>
        internal override long AsignHandle(long entityNumber)
        {
            foreach( PolylineVertex v in this.vertexes )
            {
                entityNumber = v.AsignHandle(entityNumber);
            }
            entityNumber = this.endSequence.AsignHandle(entityNumber);

            return base.AsignHandle(entityNumber);
        }

        /// <summary>
        /// Creates a new Polyline that is a copy of the current instance.
        /// </summary>
        /// <returns>A new Polyline that is a copy of this instance.</returns>
        public override object Clone()
        {
            List<PolylineVertex> copyVertexes = new List<PolylineVertex>();
            foreach (PolylineVertex vertex in this.vertexes)
            {
                copyVertexes.Add((PolylineVertex) vertex.Clone());
            }

            Polyline entity = new Polyline
            {
                //EntityObject properties
                Layer = (Layer)this.layer.Clone(),
                LineType = (LineType)this.lineType.Clone(),
                Color = (AciColor)this.color.Clone(),
                Lineweight = (Lineweight)this.lineweight.Clone(),
                Transparency = (Transparency)this.transparency.Clone(),
                LineTypeScale = this.lineTypeScale,
                Normal = this.normal,
                //Polyline properties
                Vertexes = copyVertexes,
                Flags = this.flags
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

            PointF[] points = new PointF[vertexes.Count];
            for (int i = 0; i < vertexes.Count; i++)
            {
                points[i] = new PointF((float)(vertexes[i].Location.X*factorzoom)+factor_traslacion[0],
                    (float)(vertexes[i].Location.Y*factorzoom)+factor_traslacion[1]);
            }
            switch (flags)
            {
                case PolylineTypeFlags.OpenPolyline:
                    g.DrawLines(p, points);
                    break;
                case PolylineTypeFlags.ClosedPolylineOrClosedPolygonMeshInM:
                    g.DrawPolygon(p, points);
                    break;
                default:
                    g.DrawLines(p, points);
                    break;
            }
            
        }

        #endregion
    }
}
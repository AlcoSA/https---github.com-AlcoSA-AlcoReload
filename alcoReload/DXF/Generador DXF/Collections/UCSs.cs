#region DXF.Generador_DXF, Copyright(C) 2015 Daniel Carvajal, Licensed under LGPL.
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
using DXF.Generador_DXF.Tables;

namespace DXF.Generador_DXF.Collections
{
    /// <summary>
    /// Represents a collection of user coordinate systems.
    /// </summary>
    /// <remarks>The UCSs collection method GetReferences will always return an empty list since there are no DxfObjects that references them.</remarks>
    public sealed class UCSs :
        TableObjects<UCS>
    {
        #region constructor

        internal UCSs(DxfDocument document, string handle = null)
            : this(document,0,handle)
        {
        }

        internal UCSs(DxfDocument document, int capacity, string handle = null)
            : base(document,
            new Dictionary<string, UCS>(capacity, StringComparer.OrdinalIgnoreCase),
            new Dictionary<string, List<DxfObject>>(capacity, StringComparer.OrdinalIgnoreCase),
            DxfObjectCode.UcsTable,
            handle)
        {
            this.maxCapacity = short.MaxValue;
        }

        #endregion

        #region override methods

        /// <summary>
        /// Adds a user coordinate system to the list.
        /// </summary>
        /// <param name="ucs"><see cref="UCS">User coordinate system</see> to add to the list.</param>
        /// <param name="assignHandle">Specifies if a handle needs to be generated for the user coordinate system parameter.</param>
        /// <returns>
        /// If a user coordinate system already exists with the same name as the instance that is being added the method returns the existing user coordinate system,
        /// if not it will return the new user coordinate system.
        /// </returns>
        internal override UCS Add(UCS ucs, bool assignHandle)
        {
            if (this.list.Count >= this.maxCapacity)
                throw new OverflowException(string.Format("Table overflow. The maximum number of elements the table {0} can have is {1}", this.codeName, this.maxCapacity));

            UCS add;
            if (this.list.TryGetValue(ucs.Name, out add))
                return add;

            if (assignHandle || string.IsNullOrEmpty(ucs.Handle))
                this.document.NumHandles = ucs.AsignHandle(this.document.NumHandles);

            this.document.AddedObjects.Add(ucs.Handle, ucs);
            this.list.Add(ucs.Name, ucs);
            this.references.Add(ucs.Name, new List<DxfObject>());

            ucs.Owner = this;

            ucs.NameChange += this.Item_NameChange;

            return ucs;
        }

        /// <summary>
        /// Removes a user coordinate system.
        /// </summary>
        /// <param name="name"><see cref="UCS">User coordinate system</see> name to remove from the document.</param>
        /// <returns>True if the user coordinate system has been successfully removed, or false otherwise.</returns>
        /// <remarks>Reserved user coordinate system or any other referenced by objects cannot be removed.</remarks>
        public override bool Remove(string name)
        {
            return this.Remove(this[name]);
        }

        /// <summary>
        /// Removes a user coordinate system.
        /// </summary>
        /// <param name="ucs"><see cref="UCS">User coordinate system</see> to remove from the document.</param>
        /// <returns>True if the user coordinate system has been successfully removed, or false otherwise.</returns>
        /// <remarks>Reserved user coordinate system or any other referenced by objects cannot be removed.</remarks>
        public override bool Remove(UCS ucs)
        {
            if (ucs == null)
                return false;

            if (!this.Contains(ucs))
                return false;

            if (ucs.IsReserved)
                return false;

            if (this.references[ucs.Name].Count != 0)
                return false;
     
            this.document.AddedObjects.Remove(ucs.Handle);
            this.references.Remove(ucs.Name);
            this.list.Remove(ucs.Name);

            ucs.Handle = null;
            ucs.Owner = null;

            ucs.NameChange -= this.Item_NameChange;

            return true;
        }

        #endregion

        #region UCS events

        private void Item_NameChange(TableObject sender, TableObjectChangeEventArgs<string> e)
        {
            if (this.Contains(e.NewValue))
                throw new ArgumentException("There is already another UCS with the same name.");

            this.list.Remove(sender.Name);
            this.list.Add(e.NewValue, (UCS)sender);

            List<DxfObject> refs = this.references[sender.Name];
            this.references.Remove(sender.Name);
            this.references.Add(e.NewValue, refs);
        }

        #endregion

    }
}
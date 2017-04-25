using System.Collections.Generic;

namespace DXF.Importador_DXF
{
        public class DXFGroup : DXFEntity
        {
            public DXFGroup()
            {
                Complex = true;
            }

            public List<DXFEntity> Entities = new List<DXFEntity>();
            public override bool AddEntity(DXFEntity E)
            {
                Entities.Add(E);
                return (E != null);
            }
            public void Iterate(CADEntityProc Proc, CADIterate Params)
            {
                foreach (DXFEntity Ent in Entities)
                {
                    Ent.Invoke(Proc, Params);
                }
            }
        }
    }


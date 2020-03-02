using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpreuveIzabela.DAL.Infra
{
    // pour une classe intermediare 
    // dans le struct int on ne peut pas mettre 2 valeurs 
    // nous avons besoin de 2 id  de 2 tab => il faut creer un struct de 2 elements = ici CompositeKey de Infra
    public struct CompositeKey<T, U>
    {
        public T PK1;
        public U PK2;
    }

    public struct CompositeKey<T, U, V>
    {
        public T PK1;
        public U PK2;
        public V PK3;
    }
    public struct CompositeKey<T, U, V, W>
    {
        public T PK1;
        public U PK2;
        public V PK3;
        public W PK4;
    }

}

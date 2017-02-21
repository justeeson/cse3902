using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace SuperMario.Interfaces
{
    public interface IObject
    {
        Rectangle Area { get; set; }
    }
}

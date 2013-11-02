using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Core
{
    public class UnitAttribute
    {
        #region Fields
        EnumAttributeType type;
        int intValue;
        #endregion

        #region Constructors
        public UnitAttribute(EnumAttributeType _type)
        {
            this.type = _type;
        }

        /// <summary>
        /// The full constructor for a UnitAttribute
        /// </summary>
        /// <param name="_type">The type of Attribute being returned</param>
        /// <param name="_value">The value of the attribute. NOTE: When creating EPOCHAL items, this value should be set to the HIGHEST POSSIBLE value you want for that item</param>
        public UnitAttribute(EnumAttributeType _type, int _value)
        {
            this.type = _type;
            this.intValue = _value;
        }

        /// <summary>
        /// Only used for XML Serialization
        /// </summary>
        public UnitAttribute()
        { }
        #endregion

        #region Properties

        public EnumAttributeType Type
        {
            set { type = value; }
            get { return type; }
        }

        public int IntValue
        {
            get { return intValue; }
            set { intValue = value; }
        }
        #endregion

    }
}

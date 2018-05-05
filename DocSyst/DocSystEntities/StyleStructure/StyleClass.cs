using DocSystEntities.ObserverInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocSystEntities.StyleStructure 
{
    public class StyleClass : IObserver, ISubject
    {
        private Guid id;
        private string name;
        private IList<Style> properStyles;
        private StyleClass inheritedStyleClass;
        private IList<Style> inheritedStyles;
        private IList<Style> inheritedPlusProperStyles;

        public StyleClass()
        {
            this.Id = Guid.NewGuid();
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyles = new List<Style>();
        }

        public StyleClass(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyles = new List<Style>();
        }

        public StyleClass(string name, IList<Style> properStyles, IList<Style> inheritedStyles)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            if (properStyles != null)
            {
                this.ProperStyles = properStyles;
            }
            else
            {
                this.ProperStyles = new List<Style>();
            }
            if (inheritedStyles != null)
            {
                this.InheritedStyles = inheritedStyles;
            }
            else
            {
                this.InheritedStyles = new List<Style>();
            }
            MergeInheritedAndProperStyles();
        }

        public Guid Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public IList<Style> ProperStyles
        {
            get
            {
                return properStyles;
            }

            set
            {
                properStyles = value;
            }
        }

        public StyleClass InheritedStyleClass
        {
            get
            {
                return inheritedStyleClass;
            }

            set
            {
                inheritedStyleClass = value;
            }
        }

        public IList<Style> InheritedPlusProperStyles
        {
            get
            {
                return inheritedPlusProperStyles;
            }

            set
            {
                inheritedPlusProperStyles = value;
            }
        }

        public IList<Style> InheritedStyles
        {
            get
            {
                return inheritedStyles;
            }

            set
            {
                inheritedStyles = value;
            }
        }

        public void AddStyle(Style style)
        {
            if (ProperStyles.Contains(style))
            {
                ProperStyles.Remove(style);
            }
            ProperStyles.Add(style);
            MergeInheritedAndProperStyles();
        }

        public void RemoveStyle(Style style)
        {
            if (ProperStyles.Contains(style))
            {
                ProperStyles.Remove(style);
            }
            MergeInheritedAndProperStyles();
        }

        private void MergeInheritedAndProperStyles()
        {
            InheritedPlusProperStyles = this.InheritedStyles;
            foreach(Style properStyle in this.ProperStyles)
            {
                if (InheritedPlusProperStyles.Contains(properStyle))
                {
                    InheritedPlusProperStyles.Remove(properStyle);
                }
                InheritedPlusProperStyles.Add(properStyle);
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Add(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Delete(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}

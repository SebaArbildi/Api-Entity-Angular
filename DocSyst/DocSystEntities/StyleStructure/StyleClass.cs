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
        private IList<Style> inheritedPlusProperStyles;

        public StyleClass()
        {
            this.Id = Guid.NewGuid();
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyleClass = null;
        }

        public StyleClass(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyleClass = null;
        }

        public StyleClass(string name, IList<Style> properStyles, StyleClass inheritedStyleClass)
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
            this.InheritedStyleClass = inheritedStyleClass;
            this.InheritedPlusProperStyles = new List<Style>();
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

            private set
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

            private set
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

            private set
            {
                inheritedPlusProperStyles = value;
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
            if (this.InheritedStyleClass != null)
            {
                foreach(Style inheritStyle in InheritedStyleClass.InheritedPlusProperStyles)
                {
                    if (InheritedPlusProperStyles.Contains(inheritStyle))
                    {
                        InheritedPlusProperStyles.Remove(inheritStyle);
                    }
                    InheritedPlusProperStyles.Add(inheritStyle);
                }
            }

            foreach (Style properStyle in this.ProperStyles)
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

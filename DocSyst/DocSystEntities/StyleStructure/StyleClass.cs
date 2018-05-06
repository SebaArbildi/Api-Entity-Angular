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
        private IList<IObserver> observers;

        ~StyleClass()
        {
            this.NotifyObservers();
        }

        public StyleClass()
        {
            this.Id = Guid.NewGuid();
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyleClass = null;
            this.Observers = new List<IObserver>();
        }

        public StyleClass(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyleClass = null;
            this.Observers = new List<IObserver>();


        }

        public StyleClass(string name, IList<Style> properStyles, StyleClass inheritedStyleClass)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Observers = new List<IObserver>();
            if (properStyles != null)
            {
                this.ProperStyles = properStyles;
            }
            else
            {
                this.ProperStyles = new List<Style>();
            }
            this.InheritedStyleClass = inheritedStyleClass;
            if (this.InheritedStyleClass != null)
            {
                this.InheritedStyleClass.AddObserver(this);
            }
            
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

        public IList<IObserver> Observers
        {
            get
            {
                return observers;
            }

            set
            {
                observers = value;
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
            NotifyObservers();
        }

        public void RemoveStyle(Style style)
        {
            if (ProperStyles.Contains(style))
            {
                ProperStyles.Remove(style);
            }
            MergeInheritedAndProperStyles();
            NotifyObservers();
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

        public void UpdateSubject()
        {
            MergeInheritedAndProperStyles();
        }

        public void AddObserver(IObserver observer)
        {
            this.Observers.Add(observer);
        }

        public void DeleteObserver(IObserver observer)
        {
            this.Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach(IObserver observer in this.Observers)
            {
                observer.UpdateSubject();
            }
        }
    }
}

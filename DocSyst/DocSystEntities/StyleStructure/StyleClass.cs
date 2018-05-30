using DocSystEntities.ObserverInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocSystEntities.StyleStructure
{
    public class StyleClass : IObserver, ISubject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Style> ProperStyles { get; set;}
        public StyleClass InheritedStyleClass { get; private set; }
        public IList<Style> InheritedPlusProperStyles { get; set; }
        public IList<StyleClass> Observers { get; set; }

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
            this.Observers = new List<StyleClass>();
        }

        public StyleClass(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.ProperStyles = new List<Style>();
            this.InheritedPlusProperStyles = new List<Style>();
            this.InheritedStyleClass = null;
            this.Observers = new List<StyleClass>();


        }

        public StyleClass(string name, IList<Style> properStyles, StyleClass inheritedStyleClass)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Observers = new List<StyleClass>();
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

        public void SetInheritedStyleClass(StyleClass newInheritedStyleClass)
        {     
            if (newInheritedStyleClass != null)
            {
                if (this.InheritedStyleClass != null)
                {
                    this.InheritedStyleClass.DeleteObserver(this);
                }
                this.InheritedStyleClass = newInheritedStyleClass;
                this.InheritedStyleClass.AddObserver(this);
                MergeInheritedAndProperStyles();
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
            IList<Style> newInheritedPlusProperStyles = new List<Style>();
            if (this.InheritedStyleClass != null)
            {
                foreach (Style inheritStyle in InheritedStyleClass.InheritedPlusProperStyles)
                {
                    newInheritedPlusProperStyles.Add(inheritStyle);
                }
            }

            foreach (Style properStyle in this.ProperStyles)
            {
                if (newInheritedPlusProperStyles.Contains(properStyle))
                {
                    newInheritedPlusProperStyles.Remove(properStyle);
                }
                newInheritedPlusProperStyles.Add(properStyle);
            }
            this.InheritedPlusProperStyles = newInheritedPlusProperStyles;
        }

        public void UpdateSubject()
        {
            MergeInheritedAndProperStyles();
        }

        public void AddObserver(StyleClass observer)
        {
            this.Observers.Add((StyleClass)observer);
        }

        public void DeleteObserver(StyleClass observer)
        {
            this.Observers.Remove((StyleClass)observer);
        }

        public void NotifyObservers()
        {
            foreach (StyleClass observer in this.Observers)
            {
                observer.UpdateSubject();
            }
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            StyleClass styleClass = (StyleClass)obj;
            if (this.Id.Equals(styleClass.Id))
            {
                equals = true;
            }
            return equals;
        }

    }
}

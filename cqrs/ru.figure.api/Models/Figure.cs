using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ru.figure.api
{
    public class Figure: IValidatableObject
    {
        public Circle Circle { get; set; }
        public Triangle Triangle { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Circle == null && Triangle == null)
            {
                yield return new ValidationResult(
                    "Circle or Triangle should be set",
                    new[] { nameof(Circle), nameof(Triangle) });
            }

            if (Circle != null && Triangle != null)
            {
                yield return new ValidationResult(
                    "Only one figure should be set",
                    new[] { nameof(Circle), nameof(Triangle) });
            }
        }
    }

    public class Circle
    {
        public int Radius { get; set; }
    }

    public class Triangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public int Angle { get; set; }
    }

}

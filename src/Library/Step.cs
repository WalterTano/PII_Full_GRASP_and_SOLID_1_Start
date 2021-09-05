//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------
using System;

namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        /*
        Aplicamos el patrón EXPERT para asignar la responsabilidad de calcular el costo de cada paso
        a la clase Step. Elegimos la clase Step porque conoce el producto y la cantidad del mismo
        que se va a usar en un determinado paso y también conoce el equipo y la cantidad de tiempo
        durante la cual se va a utilizar. Con esta información, es posible calcular un subtotal por
        paso, sumando los costos de insumos y equipamiento.
        */
        public double StepCost {
            get{
                double productCost = this.Quantity * this.Input.UnitCost;
                double equipmentCost = this.Time * this.Equipment.HourlyCost;

                return productCost + equipmentCost;
            }
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }
    }
}
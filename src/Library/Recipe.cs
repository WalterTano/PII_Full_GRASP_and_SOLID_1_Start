//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"Costo total de producción: ${this.GetProductionCost()}");
        }

        /*
        Aplicamos el patrón EXPERT para asignar la responsabilidad de calcular el costo total de
        producción a la clase Recipe. Elegimos la clase Recipe porque conoce la lista de instancias
        de la clase Step necesarias para completar la receta. Ya que conoce todas las instancias de
        Step usadas, puede conocer los subtotales de todas y puede sumarlos para calcular el total
        final. 
        */
        public double GetProductionCost(){
            double result = 0;
            
            foreach(Step step in steps){
                result += step.StepCost;
            }

            return result;
        }

    }
}
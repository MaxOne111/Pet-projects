using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLifeCycle
{
   private static float _Life_Reduction = 1;
   private static float _Reduction_Speed = 0;
   private static int _Speed_Limiter = 25;

   public static float RductionSpeed
   {
      get { return _Reduction_Speed; }
      set
      {
         if (_Reduction_Speed - (_Reduction_Speed - value) >= _Reduction_Speed - value)
         {
            _Reduction_Speed = value;
         }
         else if(_Reduction_Speed - (_Reduction_Speed - value) < _Reduction_Speed - value && _Reduction_Speed > _Reduction_Speed - value)
         {
            _Reduction_Speed = 1;
         }
      }
   }
   
   public static float LifeReduction()
   {
      _Reduction_Speed += Time.deltaTime / _Speed_Limiter;
      _Life_Reduction = Mathf.Pow(2, _Reduction_Speed);
      return _Life_Reduction;
   }

}

// INTENTIONALLY BAD CODE for refactoring lab.
using System;
using System.Collections.Generic;

public class ReportGenerator {
    public void DoAllStuff(List<int> nums, string name, bool debug) {
        if(nums!=null){
            if(nums.Count>0){
                double avg=0;for(int i=0;i<nums.Count;i++){avg+=nums[i];}
                avg=avg/nums.Count;
                if(debug==true){Console.WriteLine("AVG="+avg);}
                if(name!=null && name!="" && name!=" "){
                    Console.WriteLine("User:"+name);
                }
                // magic numbers
                if(avg>42.42){
                    Console.WriteLine("ok");
                } else {
                    Console.WriteLine("not ok");
                }
            } else {
                Console.WriteLine("EMPTY");
            }
        } else {
            Console.WriteLine("NULL");
        }
    }
}

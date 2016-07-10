public class Multiple cycle two{
public static void main(String[] args){
           int num = 999;
           int count =0;
    for(count=1;(num/=10)>0;count++);
System.out.println("它是个"+count+"位的数！");
int b = 1;
while(num/b > 1){
count++;
b*=10;
if(count >= 10){
break;
}
}
System.out.println("它是个"+count+"位的数！");
}
}
//李振帮忙看下那种更好。。。
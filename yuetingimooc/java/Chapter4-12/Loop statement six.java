public class Loop statement six {
    public static void main(String[] args) {

	    int sum = 0; // 保存累加值
	    for (int i = 1; i <= 10; i++) {
	    if (i%2 ==0) {
            sum=sum+i;
			}  
            continue;
              }
	    System.out.print("1到10之间的所有偶数的和为：" + sum);
        
            int number= 0 ;
            for(int i=1;i<=15;i++){
            if(i%3 !=0){
            number=number+i;
        }
            continue;
    }
	    System.out.print("1到10之间的所有奇数的和为：" + number);

	}
}
             //备注：continue和break两种的用法一般体现在什么地方。
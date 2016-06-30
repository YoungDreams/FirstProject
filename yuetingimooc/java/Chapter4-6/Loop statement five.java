public class Loop statement five{
    public static void main(String[] args) {
		int sum = 0;
		for (int i = 1; i <= 10; i++) {
		sum = sum + i;
        if (sum>20) {
		System.out.println("当前的累加值为:" + sum);
		      break;
			}
		}
        int num =0;
        for (int i = 1; i <= 10; i++) {
		num = num + i;
		if ((num=num+i)>20) {	
		System.out.println("当前的累加值为:" +num);
		      break; 
		 }
	}
}
}
          //备注：为什么两种输出结果不同。
public class Loop statement four {
    public static void main(String[] args) {

		int sum = 0; // 保存累加值
		for (int i = 1; i <= 10; i++) {
		if (i%2 !=0) {
		continue;
			}
		sum = sum + i;
		}
		System.out.print("1到10之间的所有偶数的和为：" + sum);
        
                for(int i=1;i<=10;i++){
                if(i %2 !=0){
                continue;
                         }
                System.out.println(i);
                }
  
	}
}
  //两种形式有什么不同.
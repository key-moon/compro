// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/3201/judge/4974919/C++17
//this code is written at a mock domestic contest on 2020/10/25
#include<bits/stdc++.h>

#define var auto

using namespace std;

int main(){
  int n, m;
  cin >> n >> m;
  if (n == 0) return 0;
  vector<int> as(n);
  for (int i = 0; i < n; i++){
    cin >> as[i];
  }
  vector<int> bs(m);
  for (int i = 0; i < m; i++){
    cin >> bs[i];
  }
  vector<int> res(10, 0);
  for (var&& a : as){
    for (var&& b : bs){
      var val = a * b;
      while (val != 0){
        res[val % 10]++;
        val /= 10;
      }
    }
  }
  for (int i = 0; i < 10; i++){
    if (i != 0) cout << " ";
    cout << res[i];
  }
  cout << endl;
  main();
}

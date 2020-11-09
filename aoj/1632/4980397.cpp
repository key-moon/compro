// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1632/judge/4980397/C++17
#include<bits/stdc++.h>

using namespace std;

int main(){
  int n, m;
  while (cin >> n >> m, n){  
    vector<int> sum(n);
    for (int i = 0; i < m; i++){
      for (int j = 0; j < n; j++){
        int a;
        cin >> a;
        sum[j] += a;
      }
    }
    int mx = 0;
    for (int i = 0; i < n; i++){
      mx = max(mx, sum[i]);
    }
    cout << mx << endl;
  }
}

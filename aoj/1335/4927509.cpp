// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1335/judge/4927509/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if (a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if (a < b) a = b; }

int main(){
  int n, k, s;
  cin >> n >> k >> s;
  if (n == 0) return 0;
  int res = 0;
  for (int i = 0; i < (1 << n); i++){
    int sum = 0;
    int count = 0;
    for (int j = 0; j < n; j++){
      if (!(i >> j & 1)) continue;
      sum += (j + 1);
      count++;
    }
    if (sum == s && count == k) res++;
  }
  cout << res << endl;
  main();
}


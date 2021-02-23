// detail: https://atcoder.jp/contests/abc148/submissions/20438090
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  int res = 0;
  int nxt = 1;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (a != nxt){
      res++;
    }
    else {
      nxt++;
    }
  }
  if (res == n) res = -1;
  cout << res << endl;
}

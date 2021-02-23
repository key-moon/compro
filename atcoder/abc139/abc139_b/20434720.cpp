// detail: https://atcoder.jp/contests/abc139/submissions/20434720
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int n, m;

int main() {
  int a, b;
  cin >> a >> b;
  int res = 0;
  int cur = 1;
  while (cur < b) {
    cur -= 1;
    cur += a;
    res++;
  }
  cout << res << endl;
}

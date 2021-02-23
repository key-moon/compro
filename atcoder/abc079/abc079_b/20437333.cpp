// detail: https://atcoder.jp/contests/abc079/submissions/20437333
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
  ll l1 = 2;
  ll l2 = 1;
  for (int i = 2; i <= n; i++) {
    var ln = l1 + l2;
    l1 = l2;
    l2 = ln;
  }
  cout << l2 << endl;
}

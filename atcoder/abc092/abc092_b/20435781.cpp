// detail: https://atcoder.jp/contests/abc092/submissions/20435781
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, d, x;
  cin >> n >> d >> x;
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    x += (d + a - 1) / a;
  }
  cout << x << endl;
}

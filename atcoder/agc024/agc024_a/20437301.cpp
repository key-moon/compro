// detail: https://atcoder.jp/contests/agc024/submissions/20437301
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  ll a, b, c, k;
  cin >> a >> b >> c >> k;
  if (!(k & 1)) {
    cout << a - b << endl;
  }
  else {
    cout << b - a << endl;
  }
}

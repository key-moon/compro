// detail: https://codeforces.com/contest/818/submission/107654809
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  ll n, k;
  cin >> n >> k;
  var a = (n / 2 / (1 + k));
  var b = a * k;
  var c = n - a - b;
  cout << a << " " << b << " " << c << endl;
}

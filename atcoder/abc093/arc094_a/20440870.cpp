// detail: https://atcoder.jp/contests/abc093/submissions/20440870
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  int a, b, c;
  cin >> a >> b >> c;
  var mx = max(max(a, b), c);
  var diff = (mx - a) + (mx - b) + (mx - c);
  if (diff & 1)diff += 3;
  cout << diff / 2 << endl;
}


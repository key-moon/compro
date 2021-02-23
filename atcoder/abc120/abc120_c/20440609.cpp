// detail: https://atcoder.jp/contests/abc120/submissions/20440609
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

const int MOD = (int)1e9 + 7;

int main() {
  string s;
  cin >> s; 
  var c1 = count(s.begin(), s.end(), '1');
  var c2 = count(s.begin(), s.end(), '0');
  cout << min(c1, c2) * 2 << endl;
}


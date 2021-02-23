// detail: https://atcoder.jp/contests/cf17-final/submissions/20446146
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  string s;
  cin >> s;
  int n = s.size();
  vector<int> cnts(3);
  for (var&& c : s) cnts[c - 'a']++;
  if ((*max_element(cnts.begin(), cnts.end())) - (*min_element(cnts.begin(), cnts.end())) <= 1) {
    cout << "YES" << endl;
  }
  else {
    cout << "NO" << endl;
  }
}

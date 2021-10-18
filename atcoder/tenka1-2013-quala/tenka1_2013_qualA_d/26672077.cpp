// detail: https://atcoder.jp/contests/tenka1-2013-quala/submissions/26672077
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

struct AASTNode {
  virtual ll length() { assert(false); return -1; }
  virtual void reverse() { assert(false); }
  virtual void write(string& res, ll& ptr, ll len) { assert(false); }
};

struct ASTNode : public AASTNode {
  vector<pair<AASTNode*, int>> childlen;
  ll len = -1;
  virtual ll length() {
    if (len == -1) {
      len = 0;
      for (var [child, rep] : childlen) len += child->length() * rep;
    }
    return len;
  }
  virtual void reverse() {
    std::reverse(childlen.begin(), childlen.end());
    for (var [child, _] : childlen) {
      child->reverse();
    }
  }
  virtual void write(string& res, ll& ptr, ll len) {
    for (var [child, rep] : childlen) {
      ll remain_rep = rep;
      if (ptr < 0) {
        var repcnt = min((-ptr) / child->length(), remain_rep);
        ptr += child->length() * repcnt;
        remain_rep -= repcnt;
      }

      while (remain_rep != 0 && ptr < len) {
        child->write(res, ptr, len);
        remain_rep--;
      }
    }
  }
};

struct ASTLeaf : public AASTNode {
  string s;
  virtual ll length() {
    return s.size();
  }
  virtual void reverse() {
    std::reverse(s.begin(), s.end());
  }
  virtual void write(string& res, ll& ptr, ll len) {
    ll current = 0;
    if (ptr < 0) {
      var to_seek = min(length(), -ptr);
      current += to_seek;
      ptr += to_seek;
    }
    while (current < length() && ptr < len) {
      res += s[current];
      current++;
      ptr++;
    }
  }
};

AASTNode* parse(string s, int& ind) {
  if (s[ind] == '(') {
    ASTNode* res = new ASTNode();
    ind++;
    while (s[ind] != ')') {
      var ast = parse(s, ind);
      var cnt = 0LL;
      while ('0' <= s[ind] && s[ind] <= '9') {
        cnt = cnt * 10 + (s[ind] - '0');
        ind++;
      }
      if (cnt == 0) cnt = 1;
      res->childlen.emplace_back(ast, cnt);
    }
    ind++;
    return res;
  }
  else {
    assert(('a' <= s[ind] && s[ind] <= 'z') || ('A' <= s[ind] && s[ind] <= 'Z'));
    ASTLeaf* res = new ASTLeaf();
    while (('a' <= s[ind] && s[ind] <= 'z') || ('A' <= s[ind] && s[ind] <= 'Z')) {
      res->s += s[ind];
      ind++;
    }
    return res;
  }
  assert(false);
}

int main() {
  ll b, len, n;
  cin >> b >> len >> n;
  string s;
  cin >> s;
  assert(s.size() == n);
  s = '(' + s + ')';
  int ind = 0;
  var ast = parse(s, ind);
  bool reversed = false;
  if (b < 0) {
    ast->reverse();
    b = -b - len;
    reversed = true;
  }

#if LOCAL
  var alllen = ast->length();
  ll offset = 0;
  string all;
  ast->write(all, offset, alllen);
  cout << alllen << " " << all << endl;
#endif

  ll offset = -b;
  string res = "";
  ast->write(res, offset, len);
  if (reversed) std::reverse(res.begin(), res.end());

  assert(res.size() == len);
  cout << res << endl;
}
